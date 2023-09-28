export interface Naehrwert {
  nahrungID: number;
  essen: string;
  brennwert: number | null;
  proteingehalt: number | null;
  kohlenhydrate: number | null;
  zucker: number | null;
  fett: number | null;
}