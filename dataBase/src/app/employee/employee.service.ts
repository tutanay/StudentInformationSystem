import { async } from '@angular/core/testing';
import { Baglanti } from './../baglanti';
import { Lesson } from "./../Lesson";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from './employee';
import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  list: Employee[];
  lssn: Lesson[];
  btnDersler: Lesson[];
  adSoyad: Employee[];
  baglanti: Baglanti[];
  refLes: Baglanti[];
  readonly url = "http://localhost:53480/";

  constructor(private http: HttpClient) { }



  refreshList() {
    this.http.get(this.url + 'api/students/GetEmployee').toPromise().then(
      res => this.list = res as Employee[]
    );
  }

  refreshSudentInfo(id:Number)
  {
    this.http.get(this.url+'api/lessons/GetRefreshStudent/'+id);
  }


  getEmployee(id: Number) {
    return this.http.get(this.url + 'api/GetEmployee/' + id);
  }

  postEmployee(formData: Employee) {
    return this.http.post(this.url + 'api/students/PostEmployee', formData);
  }

  putEmployee(formData: Employee) {
    return this.http.put(this.url + 'api/students/PutEmployee/' + formData.EmployeeID, formData);
  }

  deleteEmployee(id: Number) {
    return this.http.delete(this.url + 'api/students/DeleteEmployeee/' + id);
  }
  
  getLesson(id: Number) {
    return this.http.get(this.url + 'api/lessons/GetStudentInfo/' + id);
  }
  getAllStudent() {
    this.http.get(this.url + 'api/lessons/GetStudent').toPromise().then(
      res => this.lssn = res as Lesson[]

    );
  }

  getButunDersler() {
    this.http.get(this.url + 'api/lessons/GetButunDersler').toPromise().then(
      res => this.btnDersler = res as Lesson[]
    );
  }

  putBaglantiInfo(formBaglanti: Baglanti) {
    return this.http.put(this.url + 'api/lessons/updateBaglantiRecord/', formBaglanti);
  }

  DeleteLessonInfo(id: Number) {
    return this.http.get(this.url + 'api/lessons/DeleteStudentInfo/' + id);
  }

  postLessonInfo(formBgl: Baglanti) {
    return this.http.post(this.url + 'api/lessons/cretaeStudentInfo', formBgl);
  }

  getOgrAdSoyad(id: Number) {
    return this.http.get(this.url + 'api/lessons/GetOgrAdSoyad/' + id).toPromise().then(res =>
      this.adSoyad = res as Employee[]);
  }
}


