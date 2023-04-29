import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  //URLs EndPoints
  private _urlBase: string = environment.services.base;
  private _addItem: string = environment.services.toDoListItem.addItem;
  private _removeItem:string = environment.services.toDoListItem.removeItem;
  private _editItem: string = environment.services.toDoListItem.editItem;
  private _completeItem: string = environment.services.toDoListItem.completeItem;
  private _moveItem: string = environment.services.toDoListItem.moveItem;
  private _path = environment.services.toDoListItem.paths;

  constructor(private _http: HttpClient) { }

  //Add Item
  public addItem(taskId:number, name:string, description:string):Observable<any>{
    let urlService = this._urlBase + this._addItem;

    let body = {
      taskId : taskId,
      name: name,
      description: description
    };

    return this._http.post(urlService, body);
  }

  //Remove Item
  public remoteItem(itemId:number):Observable<any>{

    let urlService = this._urlBase + this._removeItem.replace(this._path.id,itemId.toString());

    return this._http.delete(urlService);
  }

  //Edit Item
  public editItem(itemId:number, name:string, description:string):Observable<any>{
    let urlService = this._urlBase + this._editItem.replace(this._path.id,itemId.toString());;

    let body = {
      name: name,
      description: description
    };

    return this._http.put(urlService, body);
  }

  //Complete Item
  public completeItem(itemId:number):Observable<any>{
    let urlService = this._urlBase + this._completeItem.replace(this._path.id,itemId.toString());

    return this._http.patch(urlService,{});
  }

  //Move Item To Another Task
  public moveItem(itemId:number, taskId:number):Observable<any>{
    let urlService = this._urlBase + this._moveItem.replace(this._path.id,itemId.toString())
                                                   .replace(this._path.taskId, taskId.toString());

    return this._http.patch(urlService,{});
  }
}
