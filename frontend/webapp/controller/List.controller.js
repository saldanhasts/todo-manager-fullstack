sap.ui.define([
  "sap/ui/core/mvc/Controller",
  "sap/ui/model/json/JSONModel"
], function (Controller, JSONModel) {
  "use strict";

  return Controller.extend("todo.controller.List", {
    onInit: function () {
      this._loadTodos();
    },

    async _loadTodos() {
      const response = await fetch("http://localhost:5000/todos");
      const data = await response.json();

      this.getView().setModel(
        new JSONModel(data.todos),
        "todos"
      );
    },

    onDetail: function (oEvent) {
      const id = oEvent
        .getSource()
        .getBindingContext("todos")
        .getObject().id;

      this.getOwnerComponent()
        .getRouter()
        .navTo("detail", { id });
    }
  });
});