export interface ProductSearchResponse{
    stockcode?: number;
    name?: string;
    brand?: string;
    description?: string;
    fullTextScore?: number;
    highLights?: HighLight[];
}

export interface HighLight {
    path?: string;
    texts?: ValueTypePair[];
}

export interface ValueTypePair {
    value?: string;
    type?: string;
}
