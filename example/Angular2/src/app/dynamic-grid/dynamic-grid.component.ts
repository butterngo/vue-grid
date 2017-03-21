import { Component, OnInit, Input, Output } from '@angular/core';
import * as _ from 'underscore';

@Component({
    moduleId: module.id,
    selector: 'tuancao-dynamic-grid',
    templateUrl: 'dynamic-grid.component.html',
    styleUrls: ['dynamic-grid.component.css']
})

export class DynamicGridComponent implements OnInit {
    @Input() private columns: Array<columnDef> = new Array<columnDef>();

    @Input() private gridOptions: gridOptions;

    private _source: Array<any> = new Array<any>();

    private _pager: any = {};

    private _pagedItems: Array<any>;

    private _pageService: PagerService = new PagerService();

    private _pageSize: number;

    constructor() { }

    ngOnInit(): void {
        if (this.columns == null || this.columns == undefined) {
            alert("Column Definition of grid not provided.");
            return;
        }
        if (this.gridOptions == null || this.gridOptions == undefined) {
            alert("Grid Options not provided.");
            return;
        }
    }

    public bindData(data: Array<any>): void {
        if (data != null && data != undefined) {
            this._source = data;
        }
    }

    public clearGrid(): void {
        this._source = [];
    }

    setPage(page: number, pageSize: number = 5) {
        if (page < 1 || page > this._pager.totalPages) {
            return;
        }

        this._pager = this._pageService.getPager(this._source.length, page, pageSize);

        this._pageSize = this._pager.pageSize;

        this._pagedItems = this._source.slice(this._pager.startIndex, this._pager.endIndex + 1);
    }
}

export class columnDef {
    caption: string;
    dataField: string;
    dataType: columnDataType;
    width: string;
    display: boolean = true;
    className?: string
}

export enum columnDataType {
    Text,
    Number,
    Datetime,
    Integer,
}

export class gridOptions {
    paging: boolean = true;
    pageSize?: number;
}

export class PagerService {

    getPager(totalItems: number, currentPage: number = 1, pageSize: number) {
        let totalPages = Math.ceil(totalItems / pageSize);
        let startPage: number, endPage: number;
        if (totalPages <= 10) {
            startPage = 1;
            endPage = totalPages;
        } else {
            if (currentPage <= 6) {
                startPage = 1;
                endPage = 10;
            } else if (currentPage + 4 >= totalPages) {
                startPage = totalPages - 9;
                endPage = totalPages;
            } else {
                startPage = currentPage - 5;
                endPage = currentPage + 4;
            }
        }

        let startIndex = (currentPage - 1) * pageSize;
        let endIndex = Math.min(startIndex + pageSize - 1, totalItems - 1);

        let pages = _.range(startPage, endPage + 1);

        return {
            totalItems: totalItems,
            currentPage: currentPage,
            pageSize: pageSize,
            totalPages: totalPages,
            startPage: startPage,
            endPage: endPage,
            startIndex: startIndex,
            endIndex: endIndex,
            pages: pages
        };
    }
}