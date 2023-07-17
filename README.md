# JeMovies

**Description**
This dot net application written in c#, creates 3 endpoints that can be integrated with any Frontend application.
The application connects to the service API: http://www.omdbapi.com to get the movie data when searched and display the details of the movie.
the 3 endpoints are:
1. the search endpoint: This takes in a search word and returns a list of movies and their years as a Json response
2. The Movie Details Endpoint: This takes in the imdbID of a movie and returns details such as poster, year, writers etc.
3. The Search History Endpoint: This simply returns the list of the last five search words carried out by the search endpoint.
This app uses the Asp dot net core features such as dependency injection and also Models and controllers to create these endpoints.

**Testing the Endpoint:**
The Application comes with the Swagger UI from dot net 6 readily available. so, if the application is run, one can easily try out the endpoints.
The UI for the search endpoint is shown below:
![image](https://github.com/ifeanyieze13/Movies-search-dotnet-app/assets/65629454/ed0d4c21-9df2-4ea6-9409-bf492d1f2ab4)

