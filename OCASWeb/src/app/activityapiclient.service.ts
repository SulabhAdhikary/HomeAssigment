import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { catchError, map, tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
import { OcasActivitySignup, OcasActivity } from './companyActivity';

@Injectable()
export class ActivityapiclientService {


  constructor(private http: HttpClient)
  {

  }

  appValidationError: string;

  getAllActivity(): Observable<OcasActivitySignup[]>
  {
 
    return this.http.get<OcasActivitySignup[]>('/api/Ocas').pipe(
      catchError(this.handleError('getClient', [])))
  }


  getAllCompanyActivity(): Observable<Object>
  {

    return this.http.get<Object>('/api/DefaultActivity').pipe(
      catchError(this.handleError('getAllCompanyActivity', [])))
  }

  postConpanyActivity(dataToPost: OcasActivitySignup): Observable<Object>
  {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'      
      })
    };
 
    return this.http.post<Object>('/api/ocas', { firstName: "sulabh" }, httpOptions).pipe(
      catchError(this.handleError('post data', [])))
  }


  bubbleUpError(): Observable<Object> {
    return Observable.create(observer  => {
      
      observer.next('jai ma kali tera haat najaye khali');
      observer.complete();
      
    });
  }


  


  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error("my error"); // log to console instead

      // TODO: better job of transforming error for user consumption
      // this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
