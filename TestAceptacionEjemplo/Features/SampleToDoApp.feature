Feature: Sample ToDo App

@ToDoApp
Scenario: Añadir un Elemento a la Lista
	Given que estoy situado en la Sample ToDo App
	Then seleccionar el Primer Item
	Then seleccionar el Segundo Item
	Then encontrar el cuadro de texto para ingresar un nuevo item (escribir)
	Then hacer click en el Submit
	And  verificar si el item fue o no creado en la lista
	Then cerrar el navegador

