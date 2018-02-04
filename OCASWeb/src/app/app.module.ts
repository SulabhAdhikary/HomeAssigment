import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { TopmenuComponent } from './topmenu/topmenu.component';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AddActivityComponent } from './add-activity/add-activity.component';
import { IndexdisplayComponent } from './indexdisplay/indexdisplay.component';
import { AboutmeComponent } from './aboutme/aboutme.component';
import { ActivityapiclientService } from './activityapiclient.service';
import { DialogComponent } from './dialog/dialog.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  declarations: [
    AppComponent,
    TopmenuComponent,
    AddActivityComponent,
    IndexdisplayComponent,
    AboutmeComponent,
    DialogComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
        { path: '', component: IndexdisplayComponent },
        { path: 'Home', component: IndexdisplayComponent },
        { path: 'AddActivity', component: AddActivityComponent },
        { path: 'Activity/:id', component: AddActivityComponent },
        { path: 'About', component: AboutmeComponent }
    ]),
    HttpClientModule,
    NoopAnimationsModule
  ],
  providers: [ActivityapiclientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
