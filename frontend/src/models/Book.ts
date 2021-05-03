import Author from './Author';

export default class Book {
  id: number;
  name: string;
  author: Author;
  description?: string;
  edition?: number;
  year?: number;

  constructor(
    name: string,
    author: Author,
    id?: number,
    description?: string,
    edition?: number,
    year?: number
  ) {
    this.id = id || 0;
    this.name = name;
    this.author = author;
    this.description = description;
    this.edition = edition;
    this.year = year;
  }
}
