import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Genre } from "./models/genre.model";

@Injectable()
export class GenresServices{

  constructor(private http: HttpClient) { }

  url = "api/genres";

  getGenres()
  {
    return this.http.get<Genre[]>(this.url);
  }

  getGenreById(id: string) {
    debugger;
    return this.http.get(this.url + '/' + id);
  }

}
