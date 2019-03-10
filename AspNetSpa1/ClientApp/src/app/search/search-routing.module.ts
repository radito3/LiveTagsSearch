import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FileDetailComponent } from "./file-detail/file-detail.component";
import { FilesListComponent } from "./files-list/files-list.component";

const searchRoutes: Routes = [
  { path: 'files',  component: FilesListComponent, data: { animation: 'files' } },
  { path: 'file/:name', component: FileDetailComponent, data: { animation: 'file' } }
];

@NgModule({
  imports: [
    RouterModule.forChild(searchRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class SearchRoutingModule { }
