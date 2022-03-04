import { SmartSearchState } from '@core/store/index';
import { createSelector } from "@ngrx/store";
import { LinkClickedState } from './link-click.reducer';

const productLinkSelector = (state: SmartSearchState) => state.linkClickInfo;

export const selectSmartSearchState = createSelector(
  productLinkSelector,
  (state: LinkClickedState) => state
);
