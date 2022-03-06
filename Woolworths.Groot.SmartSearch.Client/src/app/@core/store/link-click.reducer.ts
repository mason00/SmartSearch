import { createReducer, on } from '@ngrx/store';
import { linkClickedAction } from './link-click.action';

export interface LinkClickedState {
  stockCode?: number;
  link?: string;
  searchTeam?: string;
}

export const initialState: LinkClickedState = {
  stockCode: 0,
  link: '',
  searchTeam: '',
}

export const reducer = createReducer(
  initialState,
  on(
    linkClickedAction,
    (state, {payload}) => ({...state, ...payload}),
  ),
);
