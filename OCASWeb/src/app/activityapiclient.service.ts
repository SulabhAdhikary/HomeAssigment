import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { catchError, map, tap, filter} from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
import { OcasActivitySignup, OcasActivity, CallBackAfterError, ErrorDisplayHelper } from './companyActivity';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';



@Injectable()
export class ActivityapiclientService {

  //
  // to do 
  // try to pass obserable call back function and emit the event
  // to bubble up server side erorr and display in client
  //

  constructor(private http: HttpClient)
  {

  }
  

  getAllActivity(): Observable<OcasActivitySignup[]>
  {
 
    return this.http.get<OcasActivitySignup[]>('/api/Ocas')
      .pipe(catchError(this.handleError));
  }

  

  getAllCompanyActivity(): Observable<Object>
  {

    return this.http.get<Object>('/api/DefaultActivity')
      .pipe(catchError(this.handleError))
  }

  postCompanyActivity(dataToPost: OcasActivitySignup,id:number):Observable<Object>
  {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'      
      })
    };

    if (id != 0) {
      dataToPost.id = id.toString();
    }

     return this.http.post<Object>('/api/ocas', dataToPost, httpOptions)
     .pipe<Object>(catchError(this.handleError));

  }

  private handleError<T>(error: HttpErrorResponse, caught:T) {
    if (error.error instanceof ErrorEvent)
    {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    }else
    {
      console.error(`Backend returned code ${error.status}, ` + `body was: ${error.error}`);
    }

    return new ErrorObservable(
      {
         hasError: true,
         HttpCode: error.status,
         Message: error.error
      });
  };

  

}
