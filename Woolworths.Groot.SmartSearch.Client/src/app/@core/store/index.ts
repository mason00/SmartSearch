import * as linkClick from "./link-click.reducer";

export interface SmartSearchState {
  linkClickInfo: linkClick.LinkClickedState;
};

export const initialState: SmartSearchState = {
 linkClickInfo: linkClick.initialState
};
