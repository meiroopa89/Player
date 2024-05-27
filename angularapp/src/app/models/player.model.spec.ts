import { Player } from './player.model'; // Import Player model

describe('Player', () => { // Updated description to 'Player'
  fit('should_create_player_instance', () => { // Updated test description
    const player: Player = { // Updated 'Player' to 'player'
      playerId: 1, // Adjusted property name
      name: 'Lionel Messi', // Adjusted property name
      position: 'Forward', // Adjusted property name
      number: 10, // Adjusted property name
      age: 34, // Adjusted property name
      nationality: 'Argentinian' // Adjusted property name
    };

    // Check if the player object exists
    expect(player).toBeTruthy();

    // Check individual properties of the player
    expect(player.playerId).toBe(1); // Adjusted property name
    expect(player.name).toBe('Lionel Messi'); // Adjusted property name
    expect(player.position).toBe('Forward'); // Adjusted property name
    expect(player.number).toBe(10); // Adjusted property name
    expect(player.age).toBe(34); // Adjusted property name
    expect(player.nationality).toBe('Argentinian'); // Adjusted property name
  });
});
