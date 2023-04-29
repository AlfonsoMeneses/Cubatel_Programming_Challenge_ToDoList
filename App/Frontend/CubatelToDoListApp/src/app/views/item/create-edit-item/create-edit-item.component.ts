import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ItemDto } from 'src/app/models/item.model';
import { ItemService } from 'src/app/services/item/item.service';

@Component({
  selector: 'app-create-edit-item',
  templateUrl: './create-edit-item.component.html',
  styleUrls: ['./create-edit-item.component.scss']
})
export class CreateEditItemComponent {
  @Input() item:ItemDto = new ItemDto(-1,-1,'', '',0);
  @Input() taskId:number=-1;

  @Output() createOrEditSuccessEmit= new EventEmitter<boolean>();

  //Templates
  public btnTitle:string = 'Save';

  //Validaciones
  public isWaiting: boolean = false;

  //Errors
  public hasError: boolean = false;
  public errorMessage: string = '';

  constructor(private _itemService:ItemService){}

  ngOnInit(): void {

  }

  OnCreateOrEditItem(){
    let service;

    if (this.item.idItem != -1) {
      service = this._itemService.editItem(this.item.idItem,this.item.name,this.item.description);
    }
    else{
      service = this._itemService.addItem(this.taskId,this.item.name, this.item.description);
    }

    this.isWaiting = true;
    service.subscribe(
      response =>{
        this.createOrEditSuccessEmit.emit(true);
        this.isWaiting = false;
      },
      error =>{
        this.isWaiting = false;
        this.OnError(error);
      }
    );

  }

  //Manejo Errores
  OnError(exception: any) {
    let status = exception.status;
    switch (status) {
      case 400:
        this.errorMessage = exception.error.error;
        break;

      default:
        this.errorMessage = 'Internal error, try later';
        break;
    }

    this.hasError = true;
  }
}
