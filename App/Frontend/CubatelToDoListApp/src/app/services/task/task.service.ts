import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  //URLs EndPoints
  private _urlBase: string = environment.services.base;
  private _get: string = environment.services.toDoList.get;
  private _create:string = environment.services.toDoList.create;
  private _edit: string = environment.services.toDoList.edit;
  private _delete: string = environment.services.toDoList.delete;
  private _getTaskItems: string = environment.services.toDoList.getTaskItems;
  private _path: string = environment.services.toDoList.paths.id;

  constructor(private _http: HttpClient) { }

  public getTask():Observable<any>{

    let urlService = this._urlBase + this._get;

    return this._http.get(urlService);
  }

  public createTask(name:string,description:string):Observable<any>{
    let urlService = this._urlBase + this._create;

    let body = {
      name : name,
      description: description
    };

    return this._http.post(urlService,body);
  }

  public delete(id:number):Observable<any>{
    let urlService = this._urlBase + this._delete.replace(this._path,id.toString());

    return this._http.delete(urlService);
  }
}
