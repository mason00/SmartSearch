import { createAction, props } from '@ngrx/store';
import { LinkClickedState } from './link-click.reducer';

export const enum LinkClickActionTypes {
  LinkClickInfo = '[SmartSearch] ProductLinkClicked',
}

export const linkClickedAction = createAction(
  LinkClickActionTypes.LinkClickInfo,
  props<{ payload: LinkClickedState }>()
);
