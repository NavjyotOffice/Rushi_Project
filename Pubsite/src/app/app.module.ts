import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NewsService } from './Services/news.service';
import { HttpClientModule } from '@angular/common/http';
import { HomeNewsComponent } from './home/home-news/home-news.component';
import { HomeEventsComponent } from './home/home-events/home-events.component';
import { HomeResourcesComponent } from './home/home-resources/home-resources.component';
import { HomeComponent } from './home/home.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MostPopularComponent } from './most-popular/most-popular.component';
import { MatDialogModule } from '@angular/material/dialog';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { FormsModule } from '@angular/forms';
import { SocialMediaShareComponent } from './social-media-share/social-media-share.component';
 
@NgModule({
  declarations: [
    AppComponent,
    HomeNewsComponent,
    HomeEventsComponent,
    HomeResourcesComponent,
    HomeComponent,
    MostPopularComponent,
    SocialMediaShareComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgxPaginationModule,
    NgbModule,
    MatDialogModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  entryComponents: [
  ],
  providers: [
    NewsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
