import {Injectable} from '@angular/core';
import {Http, Response} from '@angular/http';
import {Observable} from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class AjaxService{
    constructor(private _http:Http){}

    callApi(options):Observable<Response>{
        let defaultOptions:any = {
            url:'',
            method:'GET',
            data:[]
        }

        let opts = Object.assign(defaultOptions,options);

        return this._http.request(opts.url,opts).map(resp => opts.mapResp).catch(this.errorHandle);
    }

    private errorHandle(error){
        let errorMsg: string = "";
        if (typeof error.message != "undefined") {
            errorMsg = error.message;
        }
        return Observable.throw(errorMsg);
    }
}