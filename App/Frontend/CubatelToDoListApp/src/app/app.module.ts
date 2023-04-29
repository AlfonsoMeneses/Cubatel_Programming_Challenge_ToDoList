import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TaskViewComponent } from './views/task/task-view/task-view.component';
import { TaskItemsComponent } from './views/item/task-items/task-items.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { WaitingComponent } from './views/helpers/waiting/waiting.component';
import { CreateEditTaskComponent } from './views/task/create-edit-task/create-edit-task.component';
import { ErrorViewComponent } from './views/helpers/error-view/error-view.component';
import { CreateEditItemComponent } from './views/item/create-edit-item/create-edit-item.component';


@NgModule({
  declarations: [
    AppComponent,
    TaskViewComponent,
    TaskItemsComponent,
    WaitingComponent,
    CreateEditTaskComponent,
    ErrorViewComponent,
    CreateEditItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
