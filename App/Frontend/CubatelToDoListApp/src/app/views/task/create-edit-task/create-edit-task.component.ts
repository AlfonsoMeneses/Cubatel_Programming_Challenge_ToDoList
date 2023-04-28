import { Component } from '@angular/core';

@Component({
  selector: 'app-create-edit-task',
  templateUrl: './create-edit-task.component.html',
  styleUrls: ['./create-edit-task.component.scss']
})
export class CreateEditTaskComponent {

   //Datos
   public tasks: Array<any> = [];

   //Validaciones
   public isWaiting: boolean = false;

   //Errors
   public hasError: boolean = false;
   public errorMessage: string = '';
}
