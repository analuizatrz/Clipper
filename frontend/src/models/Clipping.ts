import Book from './Book';
import ClippingType from './ClippingType';

export default class Clipping {
  id: number;
  text: string;
  book: Book;
  type: ClippingType;
  page: number;
  locationStart: number;
  locationEnd: number;
  date: Date;

  constructor(
    text: string,
    book: Book,
    type: ClippingType,
    id?: number,
    page?: number,
    locationStart?: number,
    locationEnd?: number,
    date?: Date
  ) {
    this.id = id || 0;
    this.text = text;
    this.book = book;
    this.type = type;
    this.page = page || 0;
    this.locationStart = locationStart || 0;
    this.locationEnd = locationEnd || 0;
    this.date = date || new Date();
  }
}
