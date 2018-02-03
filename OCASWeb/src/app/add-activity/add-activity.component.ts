import { Component, OnInit ,ViewChild} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ActivityapiclientService } from './../activityapiclient.service'
import { OcasActivitySignup, OcasActivity} from './../companyActivity';

@Component({
  selector: 'app-add-activity',
  templateUrl: './add-activity.component.html',
  styleUrls: ['./add-activity.component.css']
})
export class AddActivityComponent implements OnInit {

    //Create empty Activity as  model
    model: OcasActivitySignup = new OcasActivitySignup();

    //Accessing the form template variable
    @ViewChild("f") form: any;



    Activities: OcasActivity[];
    constructor(private activatedRoute: ActivatedRoute, private acservice: ActivityapiclientService)
    {
      this.activatedRoute.params.subscribe(parm => console.log(parm));
    }

    ngOnInit()
    {
      this.acservice.getAllCompanyActivity().subscribe(activitiy => this.DoManipulation(activitiy));
    }

    DoManipulation(apprs: Object) {
      this.Activities = [];
      for (let prop in apprs) {
        let obj = new OcasActivity();
        obj.id = parseInt(prop);
        obj.name = apprs[prop];
        this.Activities.unshift(obj);
      }

    }


    Submit()
    {
    if (this.form.valid)
     {
      this.acservice.postConpanyActivity(this.form.value).subscribe(res => this.windongUpErroCall(res)));
      this.form.reset();
      
     }
    }

   windongUpErroCall(activity:any)
   {
     console.log('call this before checking error')
     this.acservice.bubbleUpError().subscribe(t => console.log(t));
   }

}

