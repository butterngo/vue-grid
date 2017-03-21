import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, BaseRequestOptions, RequestOptionsArgs } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class AjaxService {
    private defaultOptions : RequestOptions = new BaseRequestOptions();
    constructor(private _http: Http) { }

    callApi(customOptions: RequestOptionsArgs): Observable<Response> {
        let options = this.defaultOptions.merge(customOptions);
        return this._http.request(options.url, options).catch(this.errorHandle);
    }

    private errorHandle(error) {
        let errorMsg: string = "";
        if (typeof error.message != "undefined") {
            errorMsg = error.message;
        }
        return Observable.throw(errorMsg);
    }
}