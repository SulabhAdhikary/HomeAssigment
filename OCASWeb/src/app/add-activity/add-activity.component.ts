import { Component, OnInit ,ViewChild, Output} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ActivityapiclientService } from './../activityapiclient.service'
import { OcasActivitySignup, OcasActivity } from './../companyActivity';
import { Observable } from 'rxjs/Observable';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { FormControl } from '@angular/forms';
import { EventEmitter } from 'events';

@Component({
  selector: 'app-add-activity',
  templateUrl: './add-activity.component.html',
  styleUrls: ['./add-activity.component.css']
})
export class AddActivityComponent implements OnInit {

   @Output() dataAdded = new EventEmitter();


    //Create empty Activity as  model
    model: OcasActivitySignup = new OcasActivitySignup();

    //Accessing the form template variable
    @ViewChild("f") form: any;


   
    formErrors: string[]=[];

    activityId: number = 0;

    Activities: OcasActivity[];
    constructor(private activatedRoute: ActivatedRoute, private acservice: ActivityapiclientService, private router: Router)
    {
      //Check for Query string
      this.activatedRoute.params.subscribe(parm => this.processIncomingData(parm));
    }

    ngOnInit()
    {
      
      this.acservice.getAllCompanyActivity().subscribe(
        activitiy => this.DoManipulation(activitiy)
      ), (err: any) => {
       
        console.log(err);
      };
    }

    DoManipulation(apprs: Object)
    {
      this.Activities = [];
      for (let prop in apprs) {
        let obj = new OcasActivity();
        obj.id = parseInt(prop);
        obj.name = apprs[prop];
        this.Activities.unshift(obj);
      }
    }

    processIncomingData(para: any) {
      if ("id" in para) {
        this.activityId = para.id;
      }

      this.acservice.getAllActivity()
        .subscribe(activitiy => this.DoManipulation(activitiy));

      this.acservice.getAllActivity()
        .subscribe(activitiy => this.DoManipulationInDetail(activitiy));
    }

    Submit()
    {
      if (this.form.valid)
      {

        this.acservice.postCompanyActivity(this.form.value, this.activityId).subscribe(res => this.windingUpSuccessCall(res), err => this.windingUpErrorCall(err));
        this.dataAdded.emit("customEvent");
       
      }
    }



    DoManipulationInDetail(apprs: OcasActivitySignup[]) {
 
    for (let childObj of apprs) {
      if (childObj.id == this.activityId.toString()) {
        this.model.id = childObj.id,
        this.model.firstName = childObj.firstName;
        this.model.lastName = childObj.lastName;
        this.model.email = childObj.email;
        this.model.activityId = childObj.activityId;
        this.model.activityName = childObj.activityName,
        this.model.activity.id = Number(childObj.activityId)
        break;
      }
    }
  }

   windingUpSuccessCall(activity:any)
   {
     this.form.reset();
     this.router.navigate(['Home'])
  
   
    }


   windingUpErrorCall(activity: any)
   {

     console.log(activity.Message);
     this.formErrors = activity.Message;
         this.router.navigate(['Activity/0'])

   }

}

