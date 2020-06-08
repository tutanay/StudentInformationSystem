import { OgrSayfaComponent } from './../../../ogr-sayfa/ogr-sayfa.component';
import { Component, OnInit } from '@angular/core';
import {  Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.css']
})
export class ConfirmationDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ConfirmationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public message: string) { }

    onNoClick(): void {
      this.dialogRef.close();
    }
  ngOnInit() {
  }

}
