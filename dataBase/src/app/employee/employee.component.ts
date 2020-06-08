import { Baglanti } from './../baglanti';
import { NgForm } from '@angular/forms';
import { EmployeeService } from './employee.service';
import { Component, OnInit } from '@angular/core';
import { Employee } from './employee';
import {Router} from '@angular/router';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  providers: [EmployeeService]
})
export class EmployeeComponent implements OnInit {

  formData:Employee = new Employee();

  constructor(private employeeService: EmployeeService,private route:Router) { }

  ngOnInit() {
    this.employeeService.refreshList();
  }


  routeID(formData)
  {
    this.route.navigate(['/home',formData.EmployeeID]);

  }
  resetForm() {
    this.formData = {
      EmployeeID: null,
      Name: '',
      Surname: '',
      Number: null,
    };
  } 
 
 
  
  onSubmit() {
    
    if (this.formData.EmployeeID== null){
      this.insertRecord();
    }
    else{
            this.employeeService.putEmployee(this.formData).subscribe(res => {
               debugger;
                this.employeeService.refreshList();
                 this.resetForm();
              });

      }
  }

  insertRecord() {
    this.employeeService.postEmployee(this.formData).subscribe(res => {
      
      this.employeeService.refreshList();
      this.resetForm();
    });
  }
  updateRecord(employee: Employee) {
  
    this.formData=Object.assign({},employee);
   
 
  }

  deleteRecord( id:Number)
  {
    this.employeeService.deleteEmployee(id).subscribe(res=>{
      this.employeeService.refreshList();
      this.resetForm();
    });

  }
}

