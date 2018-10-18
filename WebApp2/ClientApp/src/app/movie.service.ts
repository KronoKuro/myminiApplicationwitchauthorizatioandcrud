import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Movie } from "./models/movie.model";

@Injectable()
export class MovieService {

  constructor(private http: HttpClient) { }

  private url: string = 'api/home';

  getMovies() {
    return this.http.get<Movie[]>(this.url);
  }

  addMovie(movie: Movie) {
    console.log(movie);
    return this.http.post<Movie>(this.url, movie);
  }
  
}
