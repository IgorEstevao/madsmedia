import React, { useState } from 'react';
import './App.css';
import VideoJS from './components/videojs/videojs';
import { VideoJSOptionsType } from './components/videojs/videojs-types';
import { BaseButton } from './style/BaseButton/base-button';
import { BaseCardVideo } from './style/BaseCardVideo/base-card-video';
import { BaseTag } from './style/BaseTag/bate-tag';

function App() {
  const playerRef = React.useRef(null);
  const videoJsOptions: VideoJSOptionsType = {
    autoplay: false,
    controls: true,
    sources: [{
      src: 'https://cdn.discordapp.com/attachments/1023740229074550804/1082065485555839036/video0-45.mp4',
      type: 'video/mp4'
    }]
  };

  const handlePlayerReady = (player:any) => {
    playerRef.current = player;

    player.on('waiting', () => {
      console.log('player is waiting');
    });

    player.on('dispose', () => {
      console.log('player will dispose');
    });
  };

  const [active,setactive] = useState(false);

  return (
    <div>
      <BaseButton text='aaaa' />
      <BaseCardVideo title='Abandon: 100 Nuki Shinai to Derarenai Fushigi na Kyoushitsu 2' />
      <BaseTag active={active} text='aaaa' onClick={() => setactive(!active)} />
      <VideoJS options={videoJsOptions} onReady={handlePlayerReady} />
    </div>
  );
}

export default App;
