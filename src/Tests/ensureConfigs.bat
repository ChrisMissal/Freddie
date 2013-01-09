if not exist Mailchimp.config (
  echo 'Mailchimp.config not found, creating...'
  call copy "%1Mailchimp.config.template" "%1Mailchimp.config"
  echo '¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯'
  echo 'Before you can run tests, you'll need to supply some values from your Mailchimp account.
  echo '________________________________________________________________________________________'
)
