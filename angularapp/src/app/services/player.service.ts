import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Player } from '../models/player.model'; // Import Player model

@Injectable({
  providedIn: 'root'
})
export class PlayerService { // Updated service name
  private apiUrl = 'https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io'; // Replace this with your API endpoint

  constructor(private http: HttpClient) { }

  addPlayer(player: Player): Observable<Player> { // Adjusted method name and parameter
    return this.http.post<Player>(`${this.apiUrl}/api/Player`, player); // Adjusted endpoint and parameter
  }

  getPlayers(): Observable<Player[]> { // Adjusted method name
    return this.http.get<Player[]>(`${this.apiUrl}/api/Player`); // Adjusted endpoint
  }

  deletePlayer(playerId: number): Observable<void> { // Adjusted method name and parameter
    const url = `${this.apiUrl}/api/Player/${playerId}`; // Adjusted the URL to match your API endpoint
    return this.http.delete<void>(url); // Adjusted endpoint and parameter
  }

  getPlayer(playerId: number): Observable<Player> { // Adjusted method name and return type
    const url = `${this.apiUrl}/api/Player/${playerId}`; // Adjusted the URL to match your API endpoint
    return this.http.get<Player>(url); // Adjusted endpoint and return type
  }
}
