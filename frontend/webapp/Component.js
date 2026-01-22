sap.ui.define([
  "sap/ui/core/UIComponent",
  "sap/ui/model/json/JSONModel"
], function (UIComponent, JSONModel) {
  "use strict";

  return UIComponent.extend("todo.Component", {
    metadata: {
      manifest: "json"
    },

    init: function () {
      UIComponent.prototype.init.apply(this, arguments);

      // modelo global simples
      const oModel = new JSONModel({});
      this.setModel(oModel);

      // inicializa o router
      this.getRouter().initialize();
    }
  });
});