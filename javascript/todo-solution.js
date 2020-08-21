function addItem() {
    var todoList = document.getElementById("todoList");
    var newItem = document.getElementById("newTodo");
    var newListItem = document.createElement("li");
    var textNode = document.createTextNode(newItem.value);
    newListItem.appendChild(textNode);
    todoList.appendChild(newListItem);
    newItem.value = "";
}

