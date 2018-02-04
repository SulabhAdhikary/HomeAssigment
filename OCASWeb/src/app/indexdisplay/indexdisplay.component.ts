import { Component, OnInit } from '@angular/core';
import { ActivityapiclientService } from './../activityapiclient.service'
import { OcasActivitySignup, OcasActivity } from './../companyActivity';
import { Router } from "@angular/router"

@Component({
  selector: 'indexdisplay',
  templateUrl: './indexdisplay.component.html',
  styleUrls: ['./indexdisplay.component.css']
})
export class IndexdisplayComponent implements OnInit {

  SelectedIndex: number = 0;
  filter: boolean = false;

  constructor(private acservice: ActivityapiclientService, private router: Router) { }

  activities: OcasActivitySignup[];

  ngOnInit() {
   
    this.acservice.getAllActivity()
      .subscribe(activitiy => this.DoManipulation(activitiy));
  }

  DoManipulation(apprs: OcasActivitySignup[]) {
    this.activities = [];
    for (let childObj of apprs) {
      let obj = new OcasActivitySignup();
      obj.id = childObj.id,
      obj.firstName = childObj.firstName;
      obj.lastName = childObj.lastName;
      obj.email = childObj.email;
      obj.activityId = childObj.activityId;
      obj.activityName = childObj.activityName
      this.activities.unshift(obj);
    }
  }


  btnAddClicked()
  {
    this.router.navigate(['Activity/0'])
  
  }

  onFilterChange(eventsargs) {
    // this.filter = !this.filter;
    this.SelectedIndex = eventsargs;
    console.log(this.SelectedIndex);
  }



}
