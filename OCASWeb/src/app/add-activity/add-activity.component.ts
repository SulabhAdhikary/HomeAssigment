import { Component, OnInit ,ViewChild} from '@angular/core';
import { ActivatedRoute } from '@angular/router'

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


    Activities: OcasActivity[] = [
        { id: 1, name: "activity 1" },
        { id: 2, name: "activity 2" },
        { id: 3, name: "activity 3" }
       ]

    constructor(private activatedRoute: ActivatedRoute) {
        this.activatedRoute.params.subscribe(parm => console.log(parm));
    }

  ngOnInit() {
  }


  Submit() {
     
      if (this.form.valid) {
          console.log('submitted the form');
          this.form.reset();
      }
  }

}

class OcasActivity {
    id: number;
    name: string;
}

class OcasActivitySignup {
    constructor(
        public firstName: string = '',
        public lastName: string = '',
        public email: string = '',
        public activity: OcasActivity = new OcasActivity()) {
    }
}
