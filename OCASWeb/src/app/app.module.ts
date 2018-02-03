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



@NgModule({
  declarations: [
    AppComponent,
    TopmenuComponent,
    AddActivityComponent,
    IndexdisplayComponent,
    AboutmeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
        { path: '', component: IndexdisplayComponent },
        { path: 'Home', component: IndexdisplayComponent },
        { path: 'AddActivity', component: AddActivityComponent },
        { path: 'About', component: AboutmeComponent }
    ]),
    HttpClientModule
  ],
  providers: [ActivityapiclientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
