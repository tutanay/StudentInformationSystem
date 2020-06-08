import { HttpClient } from '@angular/common/http';
import { Employee } from './../employee/employee';
import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  constructor( private employeeService:EmployeeService) { }

  ngOnInit() {
    this.employeeService.refreshList();
  }
  updateRecord(emp:Employee){
   // this.employeeService.form=Object.assign({},emp);
  };
  deleteRecord(id:Number){
    this.employeeService.deleteEmployee(id).subscribe
    (res=>{this.employeeService.refreshList();
    });
  }
}
