import { createReducer, on } from '@ngrx/store';
import { linkClickedAction } from './link-click.action';

export interface LinkClickedState {
  stockCode: number | undefined;
  link: string;
}

export const initialState: LinkClickedState = {
  stockCode: 0,
  link: '',
}

export const reducer = createReducer(
  initialState,
  on(
    linkClickedAction,
    (state, {payload}) => ({...state, stockCode: payload.stockCode, link: payload.link}),
  ),
);
