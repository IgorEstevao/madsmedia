// https://videojs.com/guides/options/#height
export type VideoJSOptionsType = {
  autoplay?: boolean | string;
  controls?: boolean;
  height?: string | number;
  loop?: boolean;
  muted?: boolean;
  poster?: string;
  preload?: string;
  src?: string;
  width?: string | number;
  aspectRatio?: string;
  audioOnlyMode?: boolean;
  audioPosterMode?: boolean;
  autoSetup?: boolean;
  breakpoints?: any;
  children?: any[] | any;
  fluid?: boolean;
  fullscreen?: any;
  id?: string;
  inactivityTimeout?: number;
  language?: string;
  languages?: any;
  liveui?: boolean;
  nativeControlsForTouch?: boolean;
  normalizeAutoplay?: boolean;
  notSupportedMessage?: string;
  noUITitleAttributes?: boolean;
  playbackRates?: number[];
  plugins?: any;
  preferFullWindow?: boolean;
  responsive?: boolean;
  restoreEl?: boolean;
  sources?: any[];
  suppressNotSupportedError?: boolean;
  techCanOverridePoster?: boolean;
  techOrder?: boolean;
  userActions?: any;
  html5?: boolean;
};