using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDesignAppST.Models
{
    public class MusicPlayer : INotifyPropertyChanged
    {


       

        #region properties

        private MusicFileCollection List;
        private ISoundOut _soundOut;
        private IWaveSource _waveSource;
        private System.Timers.Timer timer;
        //public event EventHandler PositionChangedEventHandler;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public PlaybackState PlaybackState
        {
            get
            {
                if (_soundOut != null)
                    return _soundOut.PlaybackState;
                return PlaybackState.Stopped;
            }
        }
        public TimeSpan Position
        {
            get
            {
                if (_waveSource != null)
                    return _waveSource.GetPosition();
                return TimeSpan.Zero;
            }
            set
            {
                if (_waveSource != null)
                {
                    _waveSource.SetPosition(value);
                    OnPropertyChanged();
                    //OnPositionChanged(EventArgs.Empty);
                }
                  

            }
        }

        public TimeSpan Length
        {
            get
            {
                if (_waveSource != null)
                    return _waveSource.GetLength();
                return TimeSpan.Zero;
            }
        }


        #endregion

        #region constructors

        public MusicPlayer():this(null)
        {
            
        }

        public MusicPlayer(MusicFileCollection list)
        {
            if (list != null)
                this.List = list;
            else
                this.List = new MusicFileCollection();
            // Create a 30 min timer 
            timer = new System.Timers.Timer(1000);

            // Hook up the Elapsed event for the timer.
            timer.Elapsed += Timer_Elapsed;
            

            timer.Enabled = true;
        }



        #endregion

        #region eventHandlers

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberNameAttribute] string propertyName = "")
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs propertyChangedEventArgs)
        {
            PropertyChanged?.Invoke(this, propertyChangedEventArgs);
        }

        //public void OnPositionChanged(EventArgs e)
        //{
        //    PositionChangedEventHandler?.Invoke(this, e);
        //}

        #endregion

        #region Methods

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_waveSource != null)
                Position = _waveSource.GetPosition();
        }
        public void Play()
        {
            CleanupPlayback();
            //if (MusicFileCollection.selectedItem == null)

            //{
            //    _waveSource = CodecFactory.Instance.GetCodec(List[0].FullName);
            //    _soundOut = new WasapiOut();
            //    _soundOut.Initialize(_waveSource);
            //    _soundOut.Play();
            //}
            //else
            //{
            //    _waveSource = CodecFactory.Instance.GetCodec(MusicFileCollection.selectedItem.FullName);
            //    _soundOut = new WasapiOut();
            //    _soundOut.Initialize(_waveSource);
            //    _soundOut.Play();
            //}
        }

        public void Play(MusicFile file)
        {
            CleanupPlayback();
            _waveSource = CodecFactory.Instance.GetCodec(file.FullName);
            _soundOut = new WasapiOut();
            _soundOut.Initialize(_waveSource);
            _soundOut.Play();
            _soundOut.WaitForStopped();

        }

        public void Pause ()
        {
            _soundOut?.Pause();
        }

        public void Stop()
        {
            if(_soundOut != null)
            _soundOut.Stop();
            CleanupPlayback();
        }

        private void CleanupPlayback()
        {
            if (_soundOut != null)
            {
                _soundOut.Dispose();
                _soundOut = null;
            }
            if (_waveSource != null)
            {
                _waveSource.Dispose();
                _waveSource = null;
            }
        }

        
        #endregion
    }
}
