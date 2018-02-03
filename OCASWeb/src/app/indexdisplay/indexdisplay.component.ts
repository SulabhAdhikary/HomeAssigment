import { Component, OnInit } from '@angular/core';
import { ActivityapiclientService } from './../activityapiclient.service'
import { OcasActivitySignup, OcasActivity } from './../companyActivity';

@Component({
  selector: 'indexdisplay',
  templateUrl: './indexdisplay.component.html',
  styleUrls: ['./indexdisplay.component.css']
})
export class IndexdisplayComponent implements OnInit {

  constructor(private acservice: ActivityapiclientService) { }

  activities: OcasActivitySignup[];

  ngOnInit() {
   
    this.acservice.getAllActivity()
   
      .subscribe(activitiy => this.DoManipulation(activitiy));
  }

  DoManipulation(apprs: OcasActivitySignup[]) {
    console.log('test called');
    this.activities = [];;

    for (let childObj of apprs) {
      let obj = new OcasActivitySignup();
      obj.firstName = childObj.firstName;
      obj.lastName = childObj.lastName;
      obj.email = childObj.email;
      obj.activityId = childObj.activityId;
      obj.activityName = childObj.activityName
      this.activities.unshift(obj);
    }
   
    console.log(this.activities);
   

  }



}
