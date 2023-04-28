import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TaskDto } from 'src/app/models/task.model';
import { TaskService } from 'src/app/services/task/task.service';

@Component({
  selector: 'app-create-edit-task',
  templateUrl: './create-edit-task.component.html',
  styleUrls: ['./create-edit-task.component.scss']
})
export class CreateEditTaskComponent implements OnInit {


   @Input() task:TaskDto = new TaskDto(-1,'', '');

   @Output() createOrEditSuccessEmit= new EventEmitter<boolean>();


   //Templates
   public btnTitle:string = 'Save';


   //Validaciones
   public isWaiting: boolean = false;

   //Errors
   public hasError: boolean = false;
   public errorMessage: string = '';

   constructor(private _taskService:TaskService){

   }
  ngOnInit(): void {
    if (this.task.idTask != -1) {
      this.btnTitle = 'Edit';
    }
  }

   setTaskVariables(){
    this.task.idTask = -1;
    this.task.name = '';
    this.task.description = "";
  }

  OnCreateOrEditTask(){

    let service;

    if (this.task.idTask != -1) {
      service = this._taskService.editTask(this.task);
    }
    else{
      service = this._taskService.createTask(this.task.name, this.task.description);
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
        this.errorMessage = 'Error interno , intente en otro momento';
        break;
    }

    this.hasError = true;
  }
}
