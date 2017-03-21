import { Component, ViewChild } from '@angular/core';
import { DynamicGridComponent, columnDef, columnDataType, gridOptions } from './dynamic-grid/dynamic-grid.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  private _columnDetails: Array<columnDef>;
  private _gridOptions: gridOptions;
  private _modelData: any = {};
  private _gridData: Array<any> = new Array<any>();
  private _srlNo: number;
  private _fakeData: Array<any>;

  @ViewChild('grid') private _gridComponent: DynamicGridComponent;

  constructor() {
    this._columnDetails = [
      { caption: 'Srl No', dataField: 'srlNo', dataType: columnDataType.Integer, width: '10%', display: true },
      { caption: 'Employee Name', dataField: 'employeeName', dataType: columnDataType.Text, width: '30%', display: true },
      { caption: 'Department', dataField: 'department', dataType: columnDataType.Text, width: '15%', display: true },
      { caption: 'Designation', dataField: 'designation', dataType: columnDataType.Text, width: '15%', display: true },
      { caption: 'Date Of Join', dataField: 'doj', dataType: columnDataType.Datetime, width: '15%', display: true },
      { caption: 'Salary', dataField: 'salary', dataType: columnDataType.Number, width: '15%', display: true }];

    this._gridOptions = {
      paging: true,
      pageSize: 2
    };
  }

  ngOnInit(): void {
    this._srlNo = 11;
    this.seedData();
    this._gridComponent.bindData(this._gridData);
    this._gridComponent.setPage(1, this._gridOptions.pageSize);
  }

  private seedData(): void {
    for (let i = 0; i < 15; i++) {
      let id = i + 1;
      let item: any = {
        srlNo: id,
        employeeName: 'Employee ' + id,
        department: 'Department ' + id,
        designation: 'Designation ' + id,
        doj: new Date(),
        salary: this.randomSalary(300, 900)
      }
      this._gridData.push(item);
    }
  }

  private randomSalary(min, max): number {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }

  private addData(): void {
    if (this.validateData()) {
      this._modelData.srlNo = this._srlNo;
      this._srlNo += 1;
      this._modelData.doj = new Date(this._modelData.doj);
      this._gridData.push(this._modelData);
      this.clearData();
      this._gridComponent.bindData(this._gridData);
    }
  }

  private clearData(): void {
    this._modelData = {};
  }

  private validateData(): boolean {
    let status = true;
    if (this.isUndefined(this._modelData.employeeName)) {
      alert('Employee Name never blank');
      status = false;
    }
    else if (this.isUndefined(this._modelData.department)) {
      alert('Department never blank');
      status = false;
    }
    else if (this.isUndefined(this._modelData.designation)) {
      alert('Designation never blank');
      status = false;
    }
    else if (this.isUndefined(this._modelData.salary)) {
      alert('Salary never blank');
      status = false;
    }
    else if (this.isUndefined(this._modelData.doj)) {
      alert('Date of Join never blank');
      status = false;
    }
    return status;
  }

  private isUndefined(data: any): boolean {
    return typeof (data) === "undefined";
  }

  private resetGrid(): void {
    this._gridData = [];
    this._modelData = {};
    this._gridComponent.clearGrid();
  }
}
