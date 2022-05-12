MVC ->
Model 
View 
Controller -> a csharp class that inheriits from controller class
		   -> Many Action methods


Views in MVC are called Razor view with cshtml extension

/////////////////
Entities represents the DB tables
Movie Table => Movie class columns will be mapped with properties
Genre => Genre class

Models/ViewModels/DTO (Data Transfer ) => are a visualization that uses Views  
example: Home Page => MovieCardModel => PosterUrl, Id, Title
Therefore, you create model classes based on the requirement of the view.

Repositories class/interfaces they deal with Entity classes
Services classes/interfaces they deal with Model classes
