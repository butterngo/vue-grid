import { Component, ViewChild } from '@angular/core';
import { DynamicGridComponent, columnDef, columnDataType, gridOptions } from './dynamic-grid/dynamic-grid.component';
import { AjaxService } from './shared/ajax/ajax.component';
import { RequestOptions, RequestOptionsArgs, BaseRequestOptions, RequestMethod } from "@angular/http";

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

  constructor(private _ajax: AjaxService) {
    this._columnDetails = [
      { caption: 'Category Id', dataField: 'categoryId', dataType: columnDataType.Integer, width: '10%', display: true },
      { caption: 'Category Name', dataField: 'categoryName', dataType: columnDataType.Text, width: '45%', display: true },
      { caption: 'Description', dataField: 'description', dataType: columnDataType.Text, width: '45%', display: true }]

    this._gridOptions = {
      paging: true,
      pageSize: 2
    };
  }

  ngOnInit(): void {
    this._srlNo = 11;
    this.getData();
  }

  private getData(): void {
    let options: RequestOptionsArgs = {
      method: RequestMethod.Get,
      url: 'http://localhost:5220/api/categories',
    };
    this._ajax.callApi(options).subscribe(data => {
      this._gridData = data.json();
      this._gridComponent.bindData(this._gridData);
      this._gridComponent.setPage(1, this._gridOptions.pageSize);
    }, error => {
      console.log(error);
    })
  }
}
