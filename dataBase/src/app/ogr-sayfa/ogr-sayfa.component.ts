import { Baglanti } from './../baglanti';
import { Employee } from './../employee/employee';
import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee/employee.service';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Lesson } from '../lesson';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { debug } from 'util';



@Component({
  selector: 'app-ogr-sayfa',
  templateUrl: './ogr-sayfa.component.html',
  styleUrls: ['./ogr-sayfa.component.css'],
  providers: [EmployeeService]
})
export class OgrSayfaComponent implements OnInit {

  formLess: Lesson = new Lesson();
  lssn2: Lesson[];
  ogrBilgi: Employee[];
  formBaglanti: Baglanti = new Baglanti();
  public degisken;
  public employeeID;
  constructor(private employeeService: EmployeeService, private route: ActivatedRoute) {

    // this.employeeID=this.route.snapshot.params;

  }

  ngOnInit() {
   this.employeeService.refreshSudentInfo(this.employeeID);
    let id = parseInt(this.route.snapshot.paramMap.get('id'));
    this.employeeID = id;
    this.employeeService.getOgrAdSoyad(this.employeeID);
    this.employeeService.getButunDersler();
    this.employeeService.getAllStudent();
    this.employeeService.getLesson(this.employeeID).toPromise().then(
      res => this.lssn2 = res as Lesson[]
    );
    this.formBaglanti.EmployeeID = this.employeeID;
  }

  onSubmit() {
    if (this.formBaglanti.BaglantiID == null) {
      this.insertLessonRecord();
    }

    else {

      this.employeeService.putBaglantiInfo(this.formBaglanti).subscribe(res => {
        //this.employeeService.getLesson(this.employeeID);
        this.ngOnInit();
      });

    }
   
  }
  

  insertLessonRecord() {
    this.employeeService.postLessonInfo(this.formBaglanti).subscribe(res => {
      this.ngOnInit();
    });
  }

  updateLesson(baglan: Baglanti) {
    this.formBaglanti = Object.assign({}, baglan);
  }

  getButunDersler() {
    this.employeeService.getButunDersler();
  }
  getStudentInfo(id: Number) {

    this.employeeService.getLesson(this.employeeID);
  }
  getAllStudents() {
    this.employeeService.getAllStudent();
  }


  deleteLesson(id: Number) {
    debugger;
     this.employeeService.DeleteLessonInfo(id).subscribe(res => {
      this.ngOnInit();
 //    data => console.log('success', data),
 //     error => console.log('oops', error),
  
      });
    this.employeeService.refreshSudentInfo(this.employeeID);
  }

  getStudentNameSurname(id: Number) {
    this.employeeService.getOgrAdSoyad(id);
  }
}
