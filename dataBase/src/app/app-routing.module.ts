import { EmployeeListComponent } from './employee-list/employee-list.component';
import { LoginComponent } from './login/login.component';
import { EmployeeComponent } from './employee/employee.component';
import { NgModule, ModuleWithProviders, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OgrSayfaComponent } from './ogr-sayfa/ogr-sayfa.component';


const routes: Routes = [
   {
  path:'home',component:EmployeeComponent
  },
  {
    
    path:'home/:id',component:OgrSayfaComponent
  },
  {
    path:'sign-in',component:LoginComponent
  },
  {
    path:'deneme',component:EmployeeListComponent
  }

 

];
export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
