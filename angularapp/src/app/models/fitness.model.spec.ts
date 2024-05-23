import { Fitness } from './fitness.model'; // Import Fitness model

describe('Fitness', () => { // Updated description to 'Fitness'
  fit('should_create_fitness_instance', () => { // Updated test description
    const fitness: Fitness = { // Updated 'bus' to 'fitness'
      fitnessId: 1, // Adjusted property name
      className: 'Yoga Class', // Adjusted property name
      instructorName: 'John Doe', // Adjusted property name
      classDate: '2024-05-15', // Adjusted property name
      duration: 60, // Adjusted property name
      location: 'Fitness Center' // Adjusted property name
    };

    // Check if the fitness object exists
    expect(fitness).toBeTruthy();

    // Check individual properties of the fitness class
    expect(fitness.fitnessId).toBe(1); // Adjusted property name
    expect(fitness.className).toBe('Yoga Class'); // Adjusted property name
    expect(fitness.instructorName).toBe('John Doe'); // Adjusted property name
    expect(fitness.classDate).toBe('2024-05-15'); // Adjusted property name
    expect(fitness.duration).toBe(60); // Adjusted property name
    expect(fitness.location).toBe('Fitness Center'); // Adjusted property name
  });
});
