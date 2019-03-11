import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SearchComponent } from "./search/search.component";
import { SearchFormComponent } from "./search/search-form/search-form.component";
import { FilesListComponent } from "./search/files-list/files-list.component";
import { FileDetailComponent } from "./search/file-detail/file-detail.component";
import { SearchService } from "./search/search.service";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SearchComponent,
    SearchFormComponent,
    FilesListComponent,
    FileDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'search', component: SearchComponent,
        children: [
          { path: '', component: SearchFormComponent },
          { path: 'files', component: FilesListComponent, data: { animation: 'files' } },
          { path: 'file/:name', component: FileDetailComponent, data: { animation: 'file' } }
        ]
      }
    ])
  ],
  providers: [SearchService],
  bootstrap: [AppComponent]
})
export class AppModule { }
