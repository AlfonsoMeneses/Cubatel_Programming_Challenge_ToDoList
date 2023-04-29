import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateEditTaskComponent } from './views/task/create-edit-task/create-edit-task.component';
import { TaskViewComponent } from './views/task/task-view/task-view.component';
import { TaskItemsComponent } from './views/item/task-items/task-items.component';

const routes: Routes = [
  {
    path: '',
    component:TaskViewComponent
  },
  {
    path: "task/:id",
    component:TaskItemsComponent
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
