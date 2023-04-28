import { Component, OnInit } from '@angular/core';
import { TaskService } from 'src/app/services/task/task.service';

declare var window:any;

@Component({
  selector: 'app-task-view',
  templateUrl: './task-view.component.html',
  styleUrls: ['./task-view.component.scss'],
})
export class TaskViewComponent implements OnInit {
  //Datos
  public tasks: Array<any> = [];
  public selectedTask:any = {name:''};

  public taskName:string = '';
  public description:string = '';

  //Validaciones
  public isWaiting: boolean = false;

  //Errors
  public hasError: boolean = false;
  public errorMessage: string = '';

  //Models
  confirmDeleteModel:any;
  createModal:any;

  constructor(private _taskService: TaskService) {}
  ngOnInit(): void {
    this.setModals();
    this.getTask();
  }

  setModals(){
    this.confirmDeleteModel = new window.bootstrap.Modal(
      document.getElementById("exampleModal")
    );

    this.createModal = new window.bootstrap.Modal(
      document.getElementById("createModal")
    );
  }

  getTask() {
    this.isWaiting = true;
    this._taskService.getTask().subscribe(
      (response) => {
        this.tasks = response;
        this.isWaiting = false;
      },
      (exception) => {
        this.isWaiting = false;
        this.OnError(exception);
      }
    );
  }

  setTaskVariables(){
    this.taskName = '';
    this.description = "";
  }

  //New Task
  OnViewNewTaskModal(){
    this.setTaskVariables();
    this.createModal.show();
  }

  OnCreateNewTask(){
    console.log(this.taskName, this.description);
    this.createModal.hide();
    this.isWaiting = true;
    this._taskService.createTask(this.taskName, this.description).subscribe(
      response =>{
        this.setTaskVariables();
        this.getTask();
        this.isWaiting = true;
      },
      error =>{
        this.OnError(error);
      }
    );
  }

  //Delete Task
  OnConfirmDelete(task: any) {
    this.selectedTask = task;
    this.confirmDeleteModel.show();
  }

  OnDeleteTask() {

      this.confirmDeleteModel.hide();

      this.isWaiting = true;
      this._taskService.delete(this.selectedTask.idTask).subscribe(
        (response) => {
          this.isWaiting = false;
          this.getTask();
        },
        (exception) => {
          this.isWaiting = false;
          this.OnError(exception);
        }
      );

  }

  refresh() {
    this.getTask();
  }

  //Manejo Errores
  OnError(exception: any) {
    console.log(exception);
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
