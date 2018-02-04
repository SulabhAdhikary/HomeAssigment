import { Observable } from 'rxjs/Observable';
import { HttpErrorResponse } from '@angular/common/http';


export class OcasActivitySignup {
  constructor(
    public id: string = '',
    public firstName: string = '',
    public lastName: string = '',
    public email: string = '',
    public activityId: string = '',
    public activityName: string = '',
    public activity: OcasActivity = new OcasActivity()) {
  }

  
}

export class OcasActivity {
  id: number;
  name: string;
}

export interface CallBackAfterError {

  <T>(): Observable<T>;
}


export interface ErrorDisplayHelper {
  <T>(error: HttpErrorResponse, caught: T)
}




