import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddApplicationComponent } from './add-application/add-application.component';
import { EditApplicationComponent } from  './edit-application/edit-application.component'
import { HomeComponent } from './home/home.component';
import { ViewApplicationComponent } from './view-application/view-application.component'


const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: 'full'},
  { path: 'Home', component: HomeComponent },
  { path: 'ViewApplication/:applicationId', component: ViewApplicationComponent },
  { path: 'AddApplication', component: AddApplicationComponent },
  { path:  'EditApplication/:applicayionId', component: EditApplicationComponent } 
];
  

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }