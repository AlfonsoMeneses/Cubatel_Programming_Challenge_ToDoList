export const environment = {
  services: {
    base: 'http://ec2-54-165-78-243.compute-1.amazonaws.com/todolist-service/api/',
    toDoList: {
      get: 'ToDoList',
      create: 'ToDoList',
      edit: 'ToDoList/{id}',
      delete: 'ToDoList/{id}',
      getTaskItems: 'ToDoList/{id}/items',
      paths: {
        id: '{id}'
      }
    },
    toDoListItem: {
      addItem: 'ToDoListItem',
      removeItem: 'ToDoListItem/{id}',
      editItem: 'ToDoListItem/{id}',
      completeItem: 'ToDoListItem/{id}',
      moveItem: 'ToDoListItem/{id}/{taskId}',
      paths: {
        id: '{id}',
        taskId: '{taskId}',
      }
    }
  }
};
